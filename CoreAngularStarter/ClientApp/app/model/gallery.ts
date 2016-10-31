export interface ICraftItem {
    id: number;
    name: string;
    description: string;
    imageUrl: string;
    available: boolean;
}

export class CraftItem implements ICraftItem {
    id: number;
    name: string;
    description: string;
    imageUrl: string;
    available: boolean;
}

export interface ICategory {
    id: number;
    name: string;
    description: string;
}

export class Category implements ICategory {
    constructor(
        public id: number,
        public name: string,
        public description: string
    ) { }
}