import { useState, useEffect } from "react";
import { Form, Button } from "react-bootstrap";

export interface ICuidado {
  id?: string;
  nome: string;
  descricao?: string;
  frequencia: string;
}

interface CuidadoFormProps {
  cuidado: ICuidado;
  salvarCuidado: (c: ICuidado) => void;
  cancelar: () => void;
}

const CuidadoForm = ({ cuidado, salvarCuidado, cancelar }: CuidadoFormProps) => {
  const [formData, setFormData] = useState<ICuidado>({ ...cuidado });

  useEffect(() => {
    setFormData({ ...cuidado });
  }, [cuidado]);

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    console.log("Dados do formulário antes de salvar:", formData);
    salvarCuidado(formData);
  };

  return (
    <Form onSubmit={handleSubmit}>
      <Form.Group className="mb-3">
        <Form.Label>Nome</Form.Label>
        <Form.Control
          type="text"
          name="nome"
          value={formData.nome}
          onChange={handleChange}
          required
        />
      </Form.Group>

      <Form.Group className="mb-3">
        <Form.Label>Descrição</Form.Label>
        <Form.Control
          as="textarea"
          name="descricao"
          value={formData.descricao || ""}
          onChange={handleChange}
        />
      </Form.Group>

      <Form.Group className="mb-3">
        <Form.Label>Frequência</Form.Label>
        <Form.Control
          type="text"
          name="frequencia"
          value={formData.frequencia}
          onChange={handleChange}
          required
        />
      </Form.Group>

      <div className="d-flex justify-content-end">
        <Button variant="primary" type="submit" className="me-2">
          Salvar
        </Button>
        <Button variant="secondary" onClick={cancelar}>
          Cancelar
        </Button>
      </div>
    </Form>
  );
};

export default CuidadoForm;
