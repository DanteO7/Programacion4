import { useEffect, useState } from "react";
import { createPancho, getAllPanchos } from "./services/panchos";

function App() {
  const [panchos, setPanchos] = useState([]);

  useEffect(() => {
    getAllPanchos().then(setPanchos);
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();

    const form = e.target;
    const data = new FormData(form);
    const pancho = Object.fromEntries(data);
    pancho.isVegan = pancho.isVegan ? true : false;
    const arrAderezos = pancho.condiment.split(",");
    pancho.condiment = arrAderezos;
    createPancho(pancho).then((data) => {
      setPanchos((prev) => [...prev, data]);
      form.reset();
    });
  };

  return (
    <>
      <h1>Hola</h1>
      <ul>
        {panchos.map((p) => (
          <li key={p.id}>
            {p.id} - {p.name}
          </li>
        ))}
      </ul>

      <form onSubmit={handleSubmit}>
        <label>
          Nombre:
          <input type="text" name="name" />
        </label>
        <label>
          <input type="checkbox" name="isVegan" />
          Vegano
        </label>
        <label>
          Precio:
          <input type="number" name="price" />
        </label>
        <label>
          Aderezos:
          <textarea name="condiment" />
        </label>

        <button type="submit">Enviar</button>
      </form>
    </>
  );
}

export default App;
