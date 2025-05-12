import React from "react";
import { AnimalItemProps } from "../../model/animalProps";

const AnimalItem: React.FC<AnimalItemProps> = ({
  animal,
  editarAnimal,
  handleConfirmarModalExcluir,
}: AnimalItemProps) => {
  function clickEditar() {
    editarAnimal(animal.id);
  }

  return (
    <div className="card mb-2 shadow-sm border-secondary">
      <div className="card-body">
        <div className="d-flex justify-content-between">
          <h5 className="card-title">
            <span className="badge bg-secondary me-1">{animal.id}</span> -{" "}
            {animal.nome}
          </h5>
        </div>

        <p className="card-text">{animal.descricao}</p>

        <div className="d-flex justify-content-end border-top pt-2 m-0">
          <button
            className="btn btn-sm btn-outline-primary me-2"
            onClick={clickEditar}
          >
            <i className="fas fa-pen me-2"></i>
            Editar
          </button>
          <button
            className="btn btn-sm btn-outline-danger"
            onClick={() => handleConfirmarModalExcluir(animal.id)}
          >
            <i className="fas fa-trash me-2"></i>
            Deletar
          </button>
        </div>
      </div>
    </div>
  );
};

export default AnimalItem;
