using Application.Common.Mappings;
using Application.Features.Certifications.Commands;
using Application.Interfaces.Repositories;
using AutoMapper;
using Azure.Storage.Blobs;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Features.Posts.Commands
{
    public record CreatePostCommand : IRequest<Result<Guid>>, IMapFrom<Post>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AccountID { get; set; }
        public int DisplayIndex { get; set; }
        public byte IsDeleted { get; set; }
        public byte IsEdited { get; set; }
        [NotMapped]
        [JsonIgnore]
        public IFormFile? ImageLogo { get; set; }

    }


    internal class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BlobServiceClient _blobServiceClient;

        public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, BlobServiceClient blobServiceClient)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blobServiceClient = blobServiceClient;
        }

        public async Task<Result<Guid>> Handle(CreatePostCommand command, CancellationToken cancellationToken)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient("foodiepics");
            // get file name from request and upload to azure blob storage
            var blobName = $"{Guid.NewGuid()}{command.ImageLogo?.FileName}";
            // local file path
            var blobInstance = containerInstance.GetBlobClient(blobName);

            // upload file to azure blob storage
            await blobInstance.UploadAsync(command.ImageLogo?.OpenReadStream());

            // storageAccountUrl
            var storageAccountUrl = "https://foodiestorage.blob.core.windows.net/foodiepics";
            // get blob url
            var blobUrl = $"{storageAccountUrl}/{blobName}";


            //return url of image except https://

            var post = new Post()
            {
                Title = command.Title,
                Content = command.Content,
                AccountID = command.AccountID,
                DisplayIndex = command.DisplayIndex,
                MediaURLs = blobUrl,
                IsDeleted = command.IsDeleted,
                IsEdited = command.IsEdited,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
            };

            

            await _unitOfWork.Repository<Post>().AddAsync(post);
            post.AddDomainEvent(new PostCreateEvent(post));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(post.Id, $"Post: {post.Id} Created.");
        }


    }
}
