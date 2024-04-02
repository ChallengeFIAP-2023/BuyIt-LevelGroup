import { Department } from './department';
import { Tag } from './tag';

export interface Product {
    id: number;
    nome: string;
    marca: string | null;
    cor: string | null;
    tamanho: string | null;
    material: string | null;
    observacao: string | null,
    departamento: Department,
    tags: Tag[]
}

export interface ProductQuery {
    id: number;
    nome: string;
    marca: string | null;
    cor: string | null;
    tamanho: string | null;
    material: string | null;
    observacao: string | null,
    idDepartamento: number,
    idsTags: number[]
}