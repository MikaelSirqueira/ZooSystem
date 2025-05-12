import React from "react";
import { ICuidado } from "./CuidadoForm";

interface CuidadoItemProps {
  cuidado: ICuidado;
  editarCuidado: (id: string) => void;
  handleConfirmarModalExcluir: (id: string) => void;
}

const CuidadoItem: React.FC<CuidadoItemProps> = ({
  cuidado,
  editarCuidado,
  handleConfirmarModalExcluir,
}: CuidadoItemProps) => {
  function clickEditar() {
    editarCuidado(cuidado.id!);
  }

  return (
    <div className="card mb-2 shadow-sm border-secondary">
      <div className="card-body">
        <div className="d-flex justify-content-between">
          <h5 className="card-title">
            <span className="badge bg-secondary me-1">{cuidado.id}</span> -{" "}
            {cuidado.nome}
          </h5>
        </div>

        <p className="card-text">{cuidado.descricao}</p>
        <p className="card-text">
          <small className="text-muted">Frequência: {cuidado.frequencia}</small>
        </p>

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
            onClick={() => handleConfirmarModalExcluir(cuidado.id!)}
          >
            <i className="fas fa-trash me-2"></i>
            Deletar
          </button>
        </div>
      </div>
    </div>
  );
};

export default CuidadoItem; 