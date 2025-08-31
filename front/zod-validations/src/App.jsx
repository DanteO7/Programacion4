import { useState } from "react";
import * as z from "zod";

const userValidation = z.object({
  nombre: z
    .string("Este campo debe ser una cadena de texto")
    .nonempty("Este campo no debe estar vacio")
    .max(30, "No puedes usar mas de 30 caracteres"),
  apellido: z
    .string("Este campo debe ser una cadena de texto")
    .nonempty("Este campo no debe estar vacio")
    .max(40, "No puedes usar mas de 30 caracteres"),
});

function App() {
  const init = {
    nombre: "",
    apellido: "",
  };

  const [errors, setErrors] = useState(init);

  return (
    <>
      <h1>Validaciones</h1>
      <form
        onSubmit={(e) => {
          e.preventDefault();
          const form = e.target;
          const formData = new FormData(form);

          const input = Object.fromEntries(formData);

          const result = userValidation.safeParse(input);

          if (!result.success) {
            const err = JSON.parse(result.error.message);

            let objError = {};

            err.forEach((item) => {
              const { path, message } = item;
              objError[path[0]] = message;
            });
            setErrors(objError);
          } else {
            setErrors(init);
            form.reset();
          }
        }}
      >
        <div className="control">
          <label htmlFor="nombre">Nombre:</label>
          <input type="text" name="nombre" id="nombre" />
          {errors.nombre && <p>{errors.nombre}</p>}
        </div>
        <div className="control">
          <label htmlFor="apellido">apellido:</label>
          <input type="text" name="apellido" id="apellido" />
          {errors.apellido && <p>{errors.apellido}</p>}
        </div>
        <button>Enviar</button>
      </form>
    </>
  );
}

export default App;
