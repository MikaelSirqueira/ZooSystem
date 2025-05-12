import { Table, Button } from "react-bootstrap";
import { ICuidado } from "./CuidadoForm";

interface CuidadoListaProps {
  cuidados: ICuidado[];
  editarCuidado: (id: string) => void;
  confirmarExclusao: (id: string) => void;
}

const CuidadoLista = ({
  cuidados,
  editarCuidado,
  confirmarExclusao,
}: CuidadoListaProps) => {
  return (
    <Table striped bordered hover responsive>
      <thead className="table-dark">
        <tr>
          <th>Nome</th>
          <th>Descrição</th>
          <th>Frequência</th>
          <th>Ações</th>
        </tr>
      </thead>
      <tbody>
        {cuidados.map((cuidado) => (
          <tr key={cuidado.id}>
            <td>{cuidado.nome}</td>
            <td>{cuidado.descricao}</td>
            <td>{cuidado.frequencia}</td>
            <td>
              <Button
                size="sm"
                variant="outline-primary"
                className="me-2"
                onClick={() => editarCuidado(cuidado.id!)}
              >
                <i className="fas fa-edit"></i>
              </Button>
              <Button
                size="sm"
                variant="outline-danger"
                onClick={() => confirmarExclusao(cuidado.id!)}
              >
                <i className="fas fa-trash-alt"></i>
              </Button>
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  );
};

export default CuidadoLista; 