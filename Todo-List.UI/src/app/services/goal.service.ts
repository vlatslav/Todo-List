import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Goals} from "../modules/Goal";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GoalService {
  baseUrl: string = "https://localhost:5000/api/Goal"
  constructor(private http: HttpClient) { }

  getGoals() : Observable<Goals[]>{
    return this.http.get<Goals[]>(this.baseUrl);
  }
  setIsDone(id: number, isDone: boolean){
    return this.http.post(this.baseUrl + `/${id}` + `?done=${isDone}`, null);
  }
  addGoal(goal: Goals){
    return this.http.post(this.baseUrl, goal);
  }
  deleteGoal(id: number){
    return this.http.delete(this.baseUrl+`/${id}`);
  }
}
