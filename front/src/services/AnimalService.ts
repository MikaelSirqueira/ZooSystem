import { IAnimal } from "../model/animal";
import api from "../api/api";

export const AnimalService = {
  getAnimais: async (): Promise<IAnimal[]> => {
    const response = await api.get("animal");
    return response.data.animals;
  },

  createAnimal: async (animal: IAnimal): Promise<void> => {
    await api.post("animal", animal);
  },

  updateAnimal: async (id: string, animal: IAnimal): Promise<void> => {
    const animalAtualizado = {
      ...animal,
      id: id
    };
    await api.put(`animal/${id}`, animalAtualizado);
  },

  deleteAnimal: async (id: string): Promise<void> => {
    await api.delete(`animal/${id}`);
  },
}; 