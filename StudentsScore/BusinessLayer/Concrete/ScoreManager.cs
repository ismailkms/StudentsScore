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
    public class ScoreManager : IScoreService
    {
        IScoreDal _scoreDal;

        public ScoreManager(IScoreDal scoreDal)
        {
            _scoreDal = scoreDal;
        }

        public void Add(Score t)
        {
            _scoreDal.Insert(t);
        }

        public void Delete(Score t)
        {
            _scoreDal.Delete(t);
        }

        public Score GetById(int id)
        {
            return _scoreDal.GetById(id);
        }

        public List<Score> GetList()
        {
            return _scoreDal.GetListAll();
        }

        public void Update(Score t)
        {
            _scoreDal.Update(t);
        }
    }
}
