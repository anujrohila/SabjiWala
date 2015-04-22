//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-04-22 - 18:46:07
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using OrderWala.Domain;

namespace OrderWala.DAL
{

    /// <summary>
    /// Assembler for <see cref="tblLanguage"/> and <see cref="tblLanguageDTO"/>.
    /// </summary>
    public static partial class tblLanguageAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="tblLanguageDTO"/> converted from <see cref="tblLanguage"/>.</param>
        static partial void OnDTO(this tblLanguage entity, tblLanguageDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="tblLanguage"/> converted from <see cref="tblLanguageDTO"/>.</param>
        static partial void OnEntity(this tblLanguageDTO dto, tblLanguage entity);

        /// <summary>
        /// Converts this instance of <see cref="tblLanguageDTO"/> to an instance of <see cref="tblLanguage"/>.
        /// </summary>
        /// <param name="dto"><see cref="tblLanguageDTO"/> to convert.</param>
        public static tblLanguage ToEntity(this tblLanguageDTO dto)
        {
            if (dto == null) return null;

            var entity = new tblLanguage();

            entity.LanguageId = dto.LanguageId;
            entity.LanguageName = dto.LanguageName;
            entity.Description = dto.Description;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="tblLanguage"/> to an instance of <see cref="tblLanguageDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="tblLanguage"/> to convert.</param>
        public static tblLanguageDTO ToDTO(this tblLanguage entity)
        {
            if (entity == null) return null;

            var dto = new tblLanguageDTO();

            dto.LanguageId = entity.LanguageId;
            dto.LanguageName = entity.LanguageName;
            dto.Description = entity.Description;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="tblLanguageDTO"/> to an instance of <see cref="tblLanguage"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<tblLanguage> ToEntities(this IEnumerable<tblLanguageDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="tblLanguage"/> to an instance of <see cref="tblLanguageDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<tblLanguageDTO> ToDTOs(this IEnumerable<tblLanguage> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
