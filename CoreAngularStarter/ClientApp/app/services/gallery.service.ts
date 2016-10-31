import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { ICategory, Category } from '../model/gallery';

@Injectable()
export class GalleryService {

    constructor(private _http: Http) { }

    getCategories(): Observable<ICategory[]> {
        return this._http.get('api/category')
            .map((response: Response) => <ICategory[]>response.json())
            .do(data => console.log('All categories: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    // Adds a category, if it doesn't yet exist in the list (check by name)
    addCategory(name: string, description: string): boolean {
        let categoryExists: boolean;
        /*categoryExists = this._categories.filter( (cat) => cat.name === name).length > 0;
        if (!categoryExists) {
            let maxCategoryId = this._categories.reduce( (a, b) => a.id > b.id ? a : b).id;
            this._categories.push(new Category(maxCategoryId + 1, name, description));
        }*/
        return false;
    }

    getCategory(id: number): Observable<ICategory> {
        return this._http.get('api/category?id=' + id)
            .map((response: Response) => <ICategory>response.json())
            .do(data => console.log('Cathegory: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(error: any) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}