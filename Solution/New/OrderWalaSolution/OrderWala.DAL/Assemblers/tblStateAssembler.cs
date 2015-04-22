//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-04-22 - 18:46:08
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
    /// Assembler for <see cref="tblState"/> and <see cref="tblStateDTO"/>.
    /// </summary>
    public static partial class tblStateAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="tblStateDTO"/> converted from <see cref="tblState"/>.</param>
        static partial void OnDTO(this tblState entity, tblStateDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="tblState"/> converted from <see cref="tblStateDTO"/>.</param>
        static partial void OnEntity(this tblStateDTO dto, tblState entity);

        /// <summary>
        /// Converts this instance of <see cref="tblStateDTO"/> to an instance of <see cref="tblState"/>.
        /// </summary>
        /// <param name="dto"><see cref="tblStateDTO"/> to convert.</param>
        public static tblState ToEntity(this tblStateDTO dto)
        {
            if (dto == null) return null;

            var entity = new tblState();

            entity.StateId = dto.StateId;
            entity.StateName = dto.StateName;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="tblState"/> to an instance of <see cref="tblStateDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="tblState"/> to convert.</param>
        public static tblStateDTO ToDTO(this tblState entity)
        {
            if (entity == null) return null;

            var dto = new tblStateDTO();

            dto.StateId = entity.StateId;
            dto.StateName = entity.StateName;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="tblStateDTO"/> to an instance of <see cref="tblState"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<tblState> ToEntities(this IEnumerable<tblStateDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="tblState"/> to an instance of <see cref="tblStateDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<tblStateDTO> ToDTOs(this IEnumerable<tblState> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
