using FlowerSalesStore.Domain.Entities;
using FlowerSalesStore.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerSalesStore.Domain.Mapper
{
    public class MapUserToUserViewModel
    {
        private static MapUserToUserViewModel instance = null;
        private UserViewModel UserViewModel;
        private static readonly object padlock = new object();
        private MapUserToUserViewModel()
        {
        }

        public static MapUserToUserViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new MapUserToUserViewModel();
                        }
                    }
                }
                return instance;
            }
        }



        //public List<ReviewViewModels> ReviewModelToReviewGridViewModels(IEnumerable<Review> review)
        //{
        //    List<ReviewViewModels> reviewViewModelsList = new List<ReviewViewModels>();
        //    if (review.Count() != 0)
        //    {
        //        foreach (Review item in review)
        //        {
        //            ReviewViewModels reviewViewModels = new ReviewViewModels
        //            {
        //                Id = item.Id,
        //                Name = item.Name,
        //                Description = item.Description,
        //                CategoryName = item.Category.Name
        //            };
        //            reviewViewModelsList.Add(reviewViewModels);
        //        }
        //    }
        //    return reviewViewModelsList;
        //}



        //public ReviewViewModels MapReviewModelToReviewViewModels(Review review)
        //{
        //    reviewViewModels = new ReviewViewModels();
        //    if (review != null)
        //    {
        //        reviewViewModels.Id = review.Id;
        //        reviewViewModels.CategoryName = review.Category.Name;
        //        reviewViewModels.Name = review.Name;
        //        reviewViewModels.Description = review.Description;
        //    }
        //    return reviewViewModels;
        //}

        public UserViewModel UserTOUserViewMdoel(User user)
        {
            UserViewModel = new UserViewModel();

            if(user != null)
            {
               // UserViewModel.
            }

            return UserViewModel;

        }
    }
}

