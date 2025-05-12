import { useState, useEffect } from "react";
import { Form, Button } from "react-bootstrap";
import { IAnimal } from "../../model/animal";

interface AnimalFormProps {
  animal: IAnimal;
  salvarAnimal: (a: IAnimal) => void;
  cancelar: () => void;
}

const AnimalForm = ({ animal, salvarAnimal, cancelar }: AnimalFormProps) => {
  const [formData, setFormData] = useState<IAnimal>({ ...animal });

  const converterData = (data: string) => {
    if (!data) return "";
    const [dia, mes, ano] = data.split("/");
    return `${ano}-${mes.padStart(2, "0")}-${dia.padStart(2, "0")}`;
  };

  useEffect(() => {
    setFormData({
      ...animal,
      dataNascimento: converterData(animal.dataNascimento),
    });
  }, [animal]);

  const handleChange = (
    e: React.ChangeEvent<
      HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement
    >,
  ) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    
    // Garantir que a data está no formato correto
    let dataFormatada = formData.dataNascimento;
    if (formData.dataNascimento && formData.dataNascimento.includes("-")) {
      dataFormatada = formData.dataNascimento
        .split("-")
        .reverse()
        .join("/");
    }

    const animalParaSalvar = {
      ...formData,
      dataNascimento: dataFormatada,
    };
    salvarAnimal(animalParaSalvar);
  };

  return (
    <Form onSubmit={handleSubmit}>
      <Form.Group className="mb-3">
        <Form.Label>Nome</Form.Label>
        <Form.Control
          type="text"
          name="nome"
          value={formData.nome || ""}
          onChange={handleChange}
          required
        />
      </Form.Group>

      <Form.Group className="mb-3">
        <Form.Label>Espécie</Form.Label>
        <Form.Control
          type="text"
          name="especie"
          value={formData.especie || ""}
          onChange={handleChange}
          required
        />
      </Form.Group>

      <Form.Group className="mb-3">
        <Form.Label>Descrição</Form.Label>
        <Form.Control
          as="textarea"
          rows={3}
          name="descricao"
          value={formData.descricao || ""}
          onChange={handleChange}
          required
        />
      </Form.Group>

      <Form.Group className="mb-3">
        <Form.Label>Data Nascimento</Form.Label>
        <Form.Control
          type="date"
          name="dataNascimento"
          value={formData.dataNascimento || ""}
          onChange={handleChange}
        />
      </Form.Group>

      <Form.Group className="mb-3">
        <Form.Label>Habitat</Form.Label>
        <Form.Control
          type="text"
          name="habitat"
          value={formData.habitat || ""}
          onChange={handleChange}
          required
        />
      </Form.Group>

      <Form.Group className="mb-3">
        <Form.Label>País de Origem</Form.Label>
        <Form.Control
          type="text"
          name="paisOrigem"
          value={formData.paisOrigem || ""}
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

export default AnimalForm;
