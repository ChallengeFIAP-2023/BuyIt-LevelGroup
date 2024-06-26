﻿using Buyit.Context;
using Buyit.Dtos;
using Buyit.Models;
using Microsoft.EntityFrameworkCore;

namespace Buyit.Services;
public class UsuarioService
{
    private readonly BuyitContext _context;

    public UsuarioService(BuyitContext context)
    {
        _context = context;
    }

    public async Task<List<UsuarioDto>> FindAll()
    {
        var list = await _context.Usuario
            .Include(x => x.Tags)
            .ToListAsync();

        return list.Select(entity => ConvertToDto(entity)).ToList();
    }

    public async Task<UsuarioDto> FindById(long id)
    {
        var entity = await FindEntityById(id);
        return ConvertToDto(entity);
    }

    public async Task<UsuarioDto> Create(UsuarioDto newData)
    {
        var entity = await ConvertToEntity(newData);
        _context.Usuario.Add(entity);
        await _context.SaveChangesAsync();
        return ConvertToDto(entity);
    }

    public async Task<UsuarioDto> Update(long id, UsuarioDto updatedData)
    {
        var entity = await _context.Usuario
            .Include(x => x.Tags)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
        {
            throw new KeyNotFoundException($"Objeto não encontrado com o ID: {id}.");
        }

        entity.Tags.Clear();

        if (updatedData.IdsTags != null)
        {
            var newTags = await _context.Tag.Where(t => updatedData.IdsTags.Contains(t.Id)).ToListAsync();
            foreach (var tag in newTags)
            {
                entity.Tags.Add(tag);
            }
        }

        updatedData.Id = entity.Id;
        var updatedEntity = await ConvertToEntity(updatedData);
        _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
        await _context.SaveChangesAsync();
        return ConvertToDto(entity);
    }

    public async Task Delete(long id)
    {
        var entity = await FindEntityById(id);
        _context.Usuario.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<UsuarioModel> FindEntityById(long id)
    {
        var entity = await _context.Usuario
            .Include(x => x.Tags)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Objeto não encontrado com o ID: {id}");
        }
        return entity;
    }

    public async Task<List<UsuarioDto>> FindByTagId(long id)
    {
        var list = await _context.Usuario
            .Where(u => u.Tags.Any(t => t.Id == id))
            .Include(x => x.Tags)
            .ToListAsync();

        return list.Select(x => ConvertToDto(x)).ToList();
    }

    private UsuarioDto ConvertToDto(UsuarioModel entity)
    {
        return new UsuarioDto
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Email = entity.Email,
            Senha = entity.Senha,
            UrlImagem = entity.UrlImagem,
            Cnpj = entity.Cnpj,
            IsFornecedor = entity.IsFornecedor,
            IdsTags = entity.Tags.Select(t => t.Id).ToList()
        };
    }

    private async Task<UsuarioModel> ConvertToEntity(UsuarioDto dto)
    {
        var tags = new List<TagModel>();
        if (dto.IdsTags != null && dto.IdsTags.Any())
        {
            tags = await _context.Tag.Where(tag => dto.IdsTags.Contains(tag.Id)).ToListAsync();
        }

        return new UsuarioModel
        {
            Id = dto.Id ?? 0,
            Nome = dto.Nome,
            Email = dto.Email,
            Senha = dto.Senha,
            UrlImagem = dto.UrlImagem,
            Cnpj = dto.Cnpj,
            IsFornecedor = dto.IsFornecedor,
            Tags = tags
        };
    }
}