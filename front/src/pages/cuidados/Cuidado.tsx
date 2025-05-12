import { useState, useEffect } from "react";
import { Button, Modal } from "react-bootstrap";
import TitlePage from "../../components/TitlePage";
import { ICuidado } from "./CuidadoForm";
import CuidadoForm from "./CuidadoForm";
import CuidadoLista from "./CuidadoLista";
import api from "../../api/api";

const cuidadoInicial: ICuidado = {
  id: "",
  nome: "",
  descricao: "",
  frequencia: "",
};

const Cuidado: React.FC = () => {
  const [cuidados, setCuidados] = useState<ICuidado[]>([]);
  const [cuidado, setCuidado] = useState<ICuidado>(cuidadoInicial);
  const [showModal, setShowModal] = useState(false);
  const [modalExcluir, setModalExcluir] = useState(false);

  const carregarCuidados = async () => {
    try {
      const response = await api.get("/care");
      setCuidados(response.data.cares);
    } catch (error) {
      console.error("Erro ao carregar cuidados:", error);
    }
  };

  useEffect(() => {
    carregarCuidados();
  }, []);

  const adicionarCuidado = async (entityCuidado: ICuidado) => {
    try {
      console.log("Dados do cuidado antes de salvar:", entityCuidado);
      await api.post("/care", entityCuidado);
      await carregarCuidados();
      toggleModal();
    } catch (error) {
      console.error("Erro ao adicionar cuidado:", error);
    }
  };

  const atualizarCuidado = async (c: ICuidado) => {
    try {
      console.log("Dados do cuidado antes de atualizar:", c);
      await api.put(`/care`, c);
      await carregarCuidados();
      toggleModal();
    } catch (error) {
    }
  };

  const deletarCuidado = async (id: string) => {
    try {
      await api.delete(`/care/${id}`);
      await carregarCuidados();
      setModalExcluir(false);
    } catch (error) {
    }
  };

  const editarCuidado = (id: string) => {
    const cuidadoSelecionado = cuidados.find((c) => c.id === id);
    if (cuidadoSelecionado) {
      setCuidado(cuidadoSelecionado);
      setShowModal(true);
    }
  };

  const toggleModal = () => {
    if (!showModal) {
      setCuidado(cuidadoInicial);
    }
    setShowModal(!showModal);
  };

  const confirmarExclusao = (id: string) => {
    const cuidadoSelecionado = cuidados.find((c) => c.id === id);
    setCuidado(cuidadoSelecionado || cuidadoInicial);
    setModalExcluir(true);
  };

  return (
    <>
      <TitlePage title="Cuidados">
        <Button variant="outline-secondary" onClick={toggleModal}>
          <i className="fas fa-plus"></i>
        </Button>
      </TitlePage>

      <CuidadoLista
        cuidados={cuidados}
        editarCuidado={editarCuidado}
        confirmarExclusao={confirmarExclusao}
      />

      <Modal show={showModal} onHide={toggleModal}>
        <Modal.Header closeButton>
          <Modal.Title>
            {cuidado.nome ? `Editar Cuidado ${cuidado.nome}` : "Novo Cuidado"}
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <CuidadoForm
            cuidado={cuidado}
            salvarCuidado={cuidado.id ? atualizarCuidado : adicionarCuidado}
            cancelar={() => {
              setCuidado(cuidadoInicial);
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
          <Modal.Title>Excluir Cuidado {cuidado.nome}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Tem certeza que deseja excluir o cuidado {cuidado.nome}?
        </Modal.Body>
        <Modal.Footer>
          <Button variant="success" onClick={() => deletarCuidado(cuidado.id!)}>
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

export default Cuidado;
