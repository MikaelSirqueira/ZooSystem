import { useState, useEffect } from "react";
import { Button, Modal } from "react-bootstrap";
import TitlePage from "../../components/TitlePage";
import { IAnimal } from "../../model/animal";
import AnimalForm from "./AnimalForm";
import AnimalLista from "./AnimalLista";
import api from "../../api/api";

const animalInicial: IAnimal = {
  id: "",
  nome: "",
  habitat: "",
  descricao: "",
  especie: "",
  dataNascimento: "",
  cuidados: [],
  paisOrigem: "",
};

const Animal = () => {
  const [animais, setAnimais] = useState<IAnimal[]>([]);
  const [animal, setAnimal] = useState<IAnimal>(animalInicial);
  const [showModal, setShowModal] = useState(false);
  const [modalExcluir, setModalExcluir] = useState(false);

  const carregarAnimais = async () => {
    try {
      const retorno = await api.get("animal");
      const lista: IAnimal[] = retorno.data.animals;
      setAnimais(lista);
    } catch (error) {
      console.error("Erro ao carregar animais:", error);
    }
  };

  useEffect(() => {
    carregarAnimais();
  }, []);

  const adicionarAnimal = async (entityAnimal: IAnimal) => {
    const response = await api.post("animal", entityAnimal);
    await carregarAnimais();
    toggleModal();
  };

  const atualizarAnimal = async (a: IAnimal) => {
    await api.put(`animal`, a);
    await carregarAnimais();
    toggleModal();
  };

  const deletarAnimal = async (id: string) => {
    setModalExcluir(false);
    await api.delete(`animal/${id}`);
    await carregarAnimais();
  };

  const editarAnimal = (id: string) => {
    const animalSelecionado = animais.find((a) => a.id === id);
    if (animalSelecionado) {
      setAnimal(animalSelecionado);
      setShowModal(true);
    }
  };

  const toggleModal = () => {
    if (!showModal) {
      setAnimal(animalInicial);
    }
    setShowModal(!showModal);
  };

  const confirmarExclusao = (id: string) => {
    const animalSelecionado = animais.find((a) => a.id === id);
    setAnimal(animalSelecionado || animalInicial);
    setModalExcluir(true);
  };

  return (
    <>
      <TitlePage title={"Animal"}>
        <Button variant="outline-secondary" onClick={toggleModal}>
          <i className="fas fa-plus"></i>
        </Button>
      </TitlePage>

      <AnimalLista
        animais={animais}
        editarAnimal={editarAnimal}
        confirmarExclusao={confirmarExclusao}
      />

      <Modal show={showModal} onHide={toggleModal}>
        <Modal.Header closeButton>
          <Modal.Title>
            {animal.nome ? `Editar Animal ${animal.nome}` : "Novo Animal"}
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <AnimalForm
            animal={animal}
            salvarAnimal={animal.id ? atualizarAnimal : adicionarAnimal}
            cancelar={() => {
              setAnimal(animalInicial);
              toggleModal();
            }}
          />
        </Modal.Body>
      </Modal>

      <Modal
        size="sm"
        show={modalExcluir}
        onHide={() => setModalExcluir(false)}
      >
        <Modal.Header closeButton>
          <Modal.Title>Excluir Animal {animal.nome}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Tem certeza que deseja excluir o animal {animal.nome}?
        </Modal.Body>
        <Modal.Footer>
          <Button variant="success" onClick={() => deletarAnimal(animal.id)}>
            Sim
          </Button>
          <Button variant="danger" onClick={() => setModalExcluir(false)}>
            Não
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
};

export default Animal;
