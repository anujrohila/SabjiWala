//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-04-17 - 08:15:09
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
    /// Assembler for <see cref="tblDeliveryCharge"/> and <see cref="tblDeliveryChargeDTO"/>.
    /// </summary>
    public static partial class tblDeliveryChargeAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="tblDeliveryChargeDTO"/> converted from <see cref="tblDeliveryCharge"/>.</param>
        static partial void OnDTO(this tblDeliveryCharge entity, tblDeliveryChargeDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="tblDeliveryCharge"/> converted from <see cref="tblDeliveryChargeDTO"/>.</param>
        static partial void OnEntity(this tblDeliveryChargeDTO dto, tblDeliveryCharge entity);

        /// <summary>
        /// Converts this instance of <see cref="tblDeliveryChargeDTO"/> to an instance of <see cref="tblDeliveryCharge"/>.
        /// </summary>
        /// <param name="dto"><see cref="tblDeliveryChargeDTO"/> to convert.</param>
        public static tblDeliveryCharge ToEntity(this tblDeliveryChargeDTO dto)
        {
            if (dto == null) return null;

            var entity = new tblDeliveryCharge();

            entity.DeliveryChargesId = dto.DeliveryChargesId;
            entity.StartAmount = dto.StartAmount;
            entity.EndAmount = dto.EndAmount;
            entity.Charges = dto.Charges;
            entity.IsActive = dto.IsActive;
            entity.CreationDateTime = dto.CreationDateTime;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="tblDeliveryCharge"/> to an instance of <see cref="tblDeliveryChargeDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="tblDeliveryCharge"/> to convert.</param>
        public static tblDeliveryChargeDTO ToDTO(this tblDeliveryCharge entity)
        {
            if (entity == null) return null;

            var dto = new tblDeliveryChargeDTO();

            dto.DeliveryChargesId = entity.DeliveryChargesId;
            dto.StartAmount = entity.StartAmount;
            dto.EndAmount = entity.EndAmount;
            dto.Charges = entity.Charges;
            dto.IsActive = entity.IsActive;
            dto.CreationDateTime = entity.CreationDateTime;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="tblDeliveryChargeDTO"/> to an instance of <see cref="tblDeliveryCharge"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<tblDeliveryCharge> ToEntities(this IEnumerable<tblDeliveryChargeDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="tblDeliveryCharge"/> to an instance of <see cref="tblDeliveryChargeDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<tblDeliveryChargeDTO> ToDTOs(this IEnumerable<tblDeliveryCharge> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}