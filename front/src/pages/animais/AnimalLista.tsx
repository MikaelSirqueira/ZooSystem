import { Table, Button } from "react-bootstrap";
import { IAnimal } from "../../model/animal";

interface AnimalListaProps {
  animais: IAnimal[];
  editarAnimal: (id: string) => void;
  confirmarExclusao: (id: string) => void;
}

const AnimalLista = ({
  animais,
  editarAnimal,
  confirmarExclusao,
}: AnimalListaProps) => {
  return (
    <Table striped bordered hover responsive>
      <thead className="table-dark">
        <tr>
          <th>Nome</th>
          <th>Espécie</th>
          <th>Descrição</th>
          <th>Data Nascimento</th>
          <th>Habitat</th>
          <th>País de Origem</th>
          <th>Ações</th>
        </tr>
      </thead>
      <tbody>
        {animais.map((animal) => {
          return (
            <tr key={animal.id}>
              <td>{animal.nome}</td>
              <td>{animal.especie}</td>
              <td>{animal.descricao}</td>
              <td>{animal.dataNascimento}</td>
              <td>{animal.habitat}</td>
              <td>{animal.paisOrigem}</td>
              <td>
                <Button
                  size="sm"
                  variant="outline-primary"
                  className="me-2"
                  onClick={() => editarAnimal(animal.id)}
                >
                  <i className="fas fa-edit"></i>
                </Button>
                <Button
                  size="sm"
                  variant="outline-danger"
                  onClick={() => confirmarExclusao(animal.id)}
                >
                  <i className="fas fa-trash-alt"></i>
                </Button>
              </td>
            </tr>
          );
        })}
      </tbody>
    </Table>
  );
};

export default AnimalLista;
