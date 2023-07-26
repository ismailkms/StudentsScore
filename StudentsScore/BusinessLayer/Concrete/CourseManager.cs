using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public void Add(Course t)
        {
            _courseDal.Insert(t);
        }

        public void Delete(Course t)
        {
            _courseDal.Delete(t);
        }

        public Course GetById(int id)
        {
            return _courseDal.GetById(id);
        }

        public List<Course> GetList()
        {
            return _courseDal.GetListAll();
        }

        public void Update(Course t)
        {
            _courseDal.Update(t);
        }
    }
}
