import { IAnimal } from "./animal";

export interface AnimalItemProps {
  animal: IAnimal;
  editarAnimal: (id: string) => void;
  handleConfirmarModalExcluir: (id: string) => void;
}

export interface AnimalListaProps {
  animais: IAnimal[];
  editarAnimal: (id: string) => void;
  handleConfirmarModalExcluir: (id: string) => void;
}

export interface AnimalFormProps {
  animalSelecionado: IAnimal;
  atualizarAnimal: (animal: IAnimal) => void;
  addAnimal: (animal: IAnimal) => void;
  cancelarAnimal: () => void;
}
