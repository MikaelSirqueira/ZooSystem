import React from 'react';
import { Table } from 'react-bootstrap';
import TitlePage from '../../components/TitlePage';

interface IAnimalCuidado {
  animalNome: string;
  cuidadoNome: string;
  frequencia: string;
}

const Home: React.FC = () => {
  const relacionamentos: IAnimalCuidado[] = [
    {
      animalNome: "Leão",
      cuidadoNome: "Alimentação",
      frequencia: "Diária"
    },
    {
      animalNome: "Leão",
      cuidadoNome: "Limpeza do Recinto",
      frequencia: "Semanal"
    },
    {
      animalNome: "Elefante",
      cuidadoNome: "Alimentação",
      frequencia: "Diária"
    },
    {
      animalNome: "Girafa",
      cuidadoNome: "Check-up Veterinário",
      frequencia: "Mensal"
    }
  ];

  return (
    <>
      <TitlePage title="Relacionamento Animais-Cuidados" />
      
      <Table striped bordered hover responsive>
        <thead className="table-dark">
          <tr>
            <th>Nome do Animal</th>
            <th>Nome do Cuidado</th>
            <th>Frequência</th>
          </tr>
        </thead>
        <tbody>
          {relacionamentos.map((rel, index) => (
            <tr key={index}>
              <td>{rel.animalNome}</td>
              <td>{rel.cuidadoNome}</td>
              <td>{rel.frequencia}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </>
  );
};

export default Home;