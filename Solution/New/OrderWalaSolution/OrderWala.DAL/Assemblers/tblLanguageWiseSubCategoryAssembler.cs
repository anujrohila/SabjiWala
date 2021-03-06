//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-05-07 - 11:56:52
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
    /// Assembler for <see cref="tblLanguageWiseSubCategory"/> and <see cref="tblLanguageWiseSubCategoryDTO"/>.
    /// </summary>
    public static partial class tblLanguageWiseSubCategoryAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="tblLanguageWiseSubCategoryDTO"/> converted from <see cref="tblLanguageWiseSubCategory"/>.</param>
        static partial void OnDTO(this tblLanguageWiseSubCategory entity, tblLanguageWiseSubCategoryDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="tblLanguageWiseSubCategory"/> converted from <see cref="tblLanguageWiseSubCategoryDTO"/>.</param>
        static partial void OnEntity(this tblLanguageWiseSubCategoryDTO dto, tblLanguageWiseSubCategory entity);

        /// <summary>
        /// Converts this instance of <see cref="tblLanguageWiseSubCategoryDTO"/> to an instance of <see cref="tblLanguageWiseSubCategory"/>.
        /// </summary>
        /// <param name="dto"><see cref="tblLanguageWiseSubCategoryDTO"/> to convert.</param>
        public static tblLanguageWiseSubCategory ToEntity(this tblLanguageWiseSubCategoryDTO dto)
        {
            if (dto == null) return null;

            var entity = new tblLanguageWiseSubCategory();

            entity.RowId = dto.RowId;
            entity.SubCategoryId = dto.SubCategoryId;
            entity.SubCategoryName = dto.SubCategoryName;
            entity.Description = dto.Description;
            entity.LanguageId = dto.LanguageId;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="tblLanguageWiseSubCategory"/> to an instance of <see cref="tblLanguageWiseSubCategoryDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="tblLanguageWiseSubCategory"/> to convert.</param>
        public static tblLanguageWiseSubCategoryDTO ToDTO(this tblLanguageWiseSubCategory entity)
        {
            if (entity == null) return null;

            var dto = new tblLanguageWiseSubCategoryDTO();

            dto.RowId = entity.RowId;
            dto.SubCategoryId = entity.SubCategoryId;
            dto.SubCategoryName = entity.SubCategoryName;
            dto.Description = entity.Description;
            dto.LanguageId = entity.LanguageId;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="tblLanguageWiseSubCategoryDTO"/> to an instance of <see cref="tblLanguageWiseSubCategory"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<tblLanguageWiseSubCategory> ToEntities(this IEnumerable<tblLanguageWiseSubCategoryDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="tblLanguageWiseSubCategory"/> to an instance of <see cref="tblLanguageWiseSubCategoryDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<tblLanguageWiseSubCategoryDTO> ToDTOs(this IEnumerable<tblLanguageWiseSubCategory> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
