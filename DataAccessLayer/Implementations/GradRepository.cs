﻿using DataAccessLayer.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
{
    public class GradRepository : IGradRepository
    {

        //dependency injection
        private readonly Context context;

        public GradRepository(Context context)
        {
            this.context = context;
        }

        public void Add(Grad entity)
        {
            context.Gradovi.Add(entity);
        }

        public void Delete(Grad entity)
        {
            context.Gradovi.Remove(entity);
        }

        public List<Grad> GetAll()
        {
            return context.Gradovi.ToList();
        }

        public Grad SearchById(Grad entity)
        {
            return context.Gradovi.Single(g => g.GradId == entity.GradId);
        }

        public List<Grad> SerachBy(Expression<Func<Grad, bool>> predicate)
        {
            return context.Gradovi.Where(predicate).ToList();
        }

        public void Update(Grad entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
