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
    /// Assembler for <see cref="tblCity"/> and <see cref="tblCityDTO"/>.
    /// </summary>
    public static partial class tblCityAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="tblCityDTO"/> converted from <see cref="tblCity"/>.</param>
        static partial void OnDTO(this tblCity entity, tblCityDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="tblCity"/> converted from <see cref="tblCityDTO"/>.</param>
        static partial void OnEntity(this tblCityDTO dto, tblCity entity);

        /// <summary>
        /// Converts this instance of <see cref="tblCityDTO"/> to an instance of <see cref="tblCity"/>.
        /// </summary>
        /// <param name="dto"><see cref="tblCityDTO"/> to convert.</param>
        public static tblCity ToEntity(this tblCityDTO dto)
        {
            if (dto == null) return null;

            var entity = new tblCity();

            entity.CityId = dto.CityId;
            entity.CityName = dto.CityName;
            entity.StateId = dto.StateId;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="tblCity"/> to an instance of <see cref="tblCityDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="tblCity"/> to convert.</param>
        public static tblCityDTO ToDTO(this tblCity entity)
        {
            if (entity == null) return null;

            var dto = new tblCityDTO();

            dto.CityId = entity.CityId;
            dto.CityName = entity.CityName;
            dto.StateId = entity.StateId;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="tblCityDTO"/> to an instance of <see cref="tblCity"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<tblCity> ToEntities(this IEnumerable<tblCityDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="tblCity"/> to an instance of <see cref="tblCityDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<tblCityDTO> ToDTOs(this IEnumerable<tblCity> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
