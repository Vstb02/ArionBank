using ArionBank.Application.Common.Interfaces;
using ArionBank.Application.Models;
using ArionBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IApplicationDbContext _context;
        public FeedbackService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateFeedback(FeedbackModel model)
        {
            var feedback = new Feedback()
            {
                Id = Guid.NewGuid(),
                Number = model.Number,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                Problem = model.Problem
            };

            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task<FeedbackListModel> GetAllFeedback()
        {
            FeedbackListModel feedbackList = new FeedbackListModel();
            var feedbacks = await _context.Feedbacks.ToListAsync();

            feedbackList.List = (from Item in feedbacks
                                    select new FeedbackModel()
                                    {
                                        Number = Item.Number,
                                        Name = Item.Name,
                                        Email = Item.Email,
                                        Surname = Item.Surname,
                                        Problem = Item.Problem
                                    }).ToList();

            return feedbackList;
        }
    }
}
