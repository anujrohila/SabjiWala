//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-04-17 - 08:15:08
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
using OrderWala.DAL;

namespace OrderWala.DAL
{

    /// <summary>
    /// Assembler for <see cref="tblQuantityType"/> and <see cref="tblQuantityTypeDTO"/>.
    /// </summary>
    public static partial class tblQuantityTypeAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="tblQuantityTypeDTO"/> converted from <see cref="tblQuantityType"/>.</param>
        static partial void OnDTO(this tblQuantityType entity, tblQuantityTypeDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="tblQuantityType"/> converted from <see cref="tblQuantityTypeDTO"/>.</param>
        static partial void OnEntity(this tblQuantityTypeDTO dto, tblQuantityType entity);

        /// <summary>
        /// Converts this instance of <see cref="tblQuantityTypeDTO"/> to an instance of <see cref="tblQuantityType"/>.
        /// </summary>
        /// <param name="dto"><see cref="tblQuantityTypeDTO"/> to convert.</param>
        public static tblQuantityType ToEntity(this tblQuantityTypeDTO dto)
        {
            if (dto == null) return null;

            var entity = new tblQuantityType();

            entity.QuantityTypeId = dto.QuantityTypeId;
            entity.TypeName = dto.TypeName;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="tblQuantityType"/> to an instance of <see cref="tblQuantityTypeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="tblQuantityType"/> to convert.</param>
        public static tblQuantityTypeDTO ToDTO(this tblQuantityType entity)
        {
            if (entity == null) return null;

            var dto = new tblQuantityTypeDTO();

            dto.QuantityTypeId = entity.QuantityTypeId;
            dto.TypeName = entity.TypeName;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="tblQuantityTypeDTO"/> to an instance of <see cref="tblQuantityType"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<tblQuantityType> ToEntities(this IEnumerable<tblQuantityTypeDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="tblQuantityType"/> to an instance of <see cref="tblQuantityTypeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<tblQuantityTypeDTO> ToDTOs(this IEnumerable<tblQuantityType> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
