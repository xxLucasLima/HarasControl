import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AnimalService } from '../animal-service';
import { AnimalDto } from '../models/animal-dto';
import { AnimalFormComponent } from '../animal-form/animal-form.component';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { AuthService } from '../../auth/auth.service';
@Component({
  selector: 'app-animals-list',
  templateUrl: './animals-list.component.html',
  styleUrls: ['./animals-list.component.scss'],
  standalone: true,
    imports: [
    MatTableModule,
    MatButtonModule,
  ]
})
export class AnimalsListComponent implements OnInit {
  animals: AnimalDto[] = [];
  displayedColumns = ['name', 'breed', 'sex', 'actions'];

  constructor(
    private animalService: AnimalService,
    private dialog: MatDialog,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.loadAnimals();
  }

  loadAnimals() {
    const HarasOwnerId = this.authService.getOwnerId();
    console.log(HarasOwnerId);

    if (!HarasOwnerId) {
      this.animals = [];
      return;
    }

    this.animalService.getByOwner(HarasOwnerId).subscribe({
      next: (res) => (this.animals = res),
    });
  }

  openAddDialog() {
    const dialogRef = this.dialog.open(AnimalFormComponent, {
      width: '400px',
      data: null,
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) this.loadAnimals();
    });
  }

  viewDetails(animal: AnimalDto) {
    // Abre detalhes (depois a gente implementa)
  }

  editAnimal(animal: AnimalDto) {
    // Abre modal de edição (depois a gente faz)
  }

  deleteAnimal(animal: AnimalDto) {
    // Chama delete (depois a gente faz)
  }
}
