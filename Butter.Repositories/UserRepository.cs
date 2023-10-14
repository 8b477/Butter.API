using Butter.Entities;
using Butter.Models;
using Butter.Repositories.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butter.Repositories
{
    public class UserRepository : BaseRepository<UserModel, UserEntity, int>, IUserRepository
    {
        public UserRepository(string cnstr) : base(cnstr)
        {
        }

        /// <summary>
        /// Récupère un modèle et le transforme en Entité pour la base de donnée
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public override UserEntity? ToEntite(UserModel Model)
        {
            if (Model is null) return null;

            return new UserEntity()
            {
                UserId = Model.UserId,
                BirthDate = Model.BirthDate,
                Email = Model.Email,
                NickName = Model.NickName,
                Password = Model.Password,
                Town = Model.Town,
                Genre = Model.Genre
            };
        }


        /// <summary>
        /// Récupère une entité en base de donnée et l'affiche sous un autre modèle
        /// </summary>
        /// <param name="entite"></param>
        /// <returns></returns>
        public override UserModel? ToModel(UserEntity entite)
        {
            if (entite is null) return null;

            return new UserModel()
            {
                UserId = entite.UserId,
                BirthDate = entite.BirthDate,
                Email = entite.Email,
                NickName = entite.NickName,
                Password = "***************",
                Town = entite.Town,
                Genre = entite.Genre
            };
        }
    }
}
