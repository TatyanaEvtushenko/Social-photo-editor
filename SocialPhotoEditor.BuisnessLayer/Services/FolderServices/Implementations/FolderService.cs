﻿using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.CommentServices;
using SocialPhotoEditor.BuisnessLayer.Services.CommentServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.FolderViewModels;
using SocialPhotoEditor.BuisnessLayer.ViewModels.ImageViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Repositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations;
using SociaPhotoEditor.Settings;

namespace SocialPhotoEditor.BuisnessLayer.Services.FolderServices.Implementations
{
    public class FolderService : IFolderService
    {
        private static readonly IChangedRepository<Folder> FolderRepository = new FolderRepository();
        private static readonly IRepository<Image> ImageRepository = new ImageRepository();

        private static readonly ICommentService CommentService = new CommentService();
        private static readonly ILikeService LikeService = new LikeService();

        public IEnumerable<FolderListViewModel> GetFolderLists(string userName)
        {
            return FolderRepository.GetAll().Where(x => x.OwnerId == userName).Select(x =>
                new FolderListViewModel
                {
                    Id = x.Id,
                    ImagesCount = ImageRepository.GetAll().Count(image => image.FolderId == x.Id),
                    Name = x.Name
                });
        }

        public FolderViewModel GetFolder(string folderId)
        {
            var folderModel = FolderRepository.GetFirst(folderId);
            return new FolderViewModel
            {
                Subscribe = folderModel?.Subscribe,
                Name = folderModel?.Name,
                Id = folderId,
                Images = GetMoreImages(0, folderId),
                OwnerId = folderModel?.OwnerId
            };
        }

        public IEnumerable<ImageListViewModel> GetMoreImages(int pageNumber, string folderId)
        {
            var images = ImageRepository.GetAll();
            var imagesInFolder = images.Where(x => x.FolderId == folderId);
            if (!imagesInFolder.Any())
                imagesInFolder = images.Where(x => x.OwnerId == folderId);
            var countOnPage = IntSettings.CountImageLists;
            return imagesInFolder.OrderBy(x => x.Time).Skip(countOnPage * pageNumber).Take(countOnPage).Select(x => new ImageListViewModel
            {
                FileName = x.FileName,
                CommentsCount = CommentService.GetCommentsCount(x.FileName),
                LikesCount = LikeService.GetLikesCount(x.FileName),
                CreatingTime = x.Time
            });
        }
    }
}
