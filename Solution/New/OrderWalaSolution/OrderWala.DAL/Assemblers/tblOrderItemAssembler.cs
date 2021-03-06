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
    /// Assembler for <see cref="tblOrderItem"/> and <see cref="tblOrderItemDTO"/>.
    /// </summary>
    public static partial class tblOrderItemAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="tblOrderItemDTO"/> converted from <see cref="tblOrderItem"/>.</param>
        static partial void OnDTO(this tblOrderItem entity, tblOrderItemDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="tblOrderItem"/> converted from <see cref="tblOrderItemDTO"/>.</param>
        static partial void OnEntity(this tblOrderItemDTO dto, tblOrderItem entity);

        /// <summary>
        /// Converts this instance of <see cref="tblOrderItemDTO"/> to an instance of <see cref="tblOrderItem"/>.
        /// </summary>
        /// <param name="dto"><see cref="tblOrderItemDTO"/> to convert.</param>
        public static tblOrderItem ToEntity(this tblOrderItemDTO dto)
        {
            if (dto == null) return null;

            var entity = new tblOrderItem();

            entity.OrderItemId = dto.OrderItemId;
            entity.OrderId = dto.OrderId;
            entity.ProductId = dto.ProductId;
            entity.Price = dto.Price;
            entity.Discount = dto.Discount;
            entity.CreationDateTime = dto.CreationDateTime;
            entity.Status = dto.Status;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="tblOrderItem"/> to an instance of <see cref="tblOrderItemDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="tblOrderItem"/> to convert.</param>
        public static tblOrderItemDTO ToDTO(this tblOrderItem entity)
        {
            if (entity == null) return null;

            var dto = new tblOrderItemDTO();

            dto.OrderItemId = entity.OrderItemId;
            dto.OrderId = entity.OrderId;
            dto.ProductId = entity.ProductId;
            dto.Price = entity.Price;
            dto.Discount = entity.Discount;
            dto.CreationDateTime = entity.CreationDateTime;
            dto.Status = entity.Status;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="tblOrderItemDTO"/> to an instance of <see cref="tblOrderItem"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<tblOrderItem> ToEntities(this IEnumerable<tblOrderItemDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="tblOrderItem"/> to an instance of <see cref="tblOrderItemDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<tblOrderItemDTO> ToDTOs(this IEnumerable<tblOrderItem> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
