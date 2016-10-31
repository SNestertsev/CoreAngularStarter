import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { ICategory, Category } from '../../model/gallery';
import { GalleryService } from '../../services/gallery.service';

@Component({
    selector: 'gallery',
    template: require('./gallery.component.html')
})
export class GalleryComponent implements OnInit {
    categoriesTitle: string = "Categories";
    noCategoriesMessage: string = "No categories";
    categories: ICategory[];
    selectedCategory: ICategory;
    isEditing: boolean = false;
    newCategoryName: string = "";
    errorMessage: string;

    constructor(private _galleryService: GalleryService) {
    }

    ngOnInit() {
        this._galleryService.getCategories()
            .subscribe(
            cathegories => this.categories = cathegories,
            error => this.errorMessage = <any>error);
    }

    public hasCategories(): boolean {
        return this.categories && this.categories.length > 0;
    }

    public onSelect(cathegory: ICategory): void {
        this.selectedCategory = cathegory;
    }

    public onEdit(): void {
        this.newCategoryName = "";
        this.isEditing = true;
    }

    public onAdd(): void {
        if (this.newCategoryName && this.newCategoryName.length > 0) {
            this._galleryService.addCategory(this.newCategoryName, "");
        }
    }

    public onDone(): void {
        this.isEditing = false;
    }

}
