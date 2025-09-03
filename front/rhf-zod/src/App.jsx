import { useForm } from "react-hook-form";
import * as z from "zod";
import { zodResolver } from "@hookform/resolvers/zod";

const userValidation = z.object({
  nombre: z
    .string()
    .nonempty("Este campo es requerido")
    .max(30, "No podes usar mas de 30 caracteres"),
  email: z.email("El formato no es valido").nonempty("Este campo es requerido"),
});

function App() {
  const {
    handleSubmit,
    register,
    formState: { errors },
  } = useForm({ resolver: zodResolver(userValidation) });

  const onSubmit = (data) => console.log(data);

  return (
    <main>
      <h1>React-Hook-Form + ZOD</h1>
      <form onSubmit={handleSubmit(onSubmit)}>
        <div className="control">
          <label htmlFor="nombre">Nombre: </label>
          <input type="text" id="nombre" {...register("nombre")} />
          {errors?.nombre && (
            <span className="error">{errors.nombre.message}</span>
          )}
        </div>
        <div className="control">
          <label htmlFor="email">Email: </label>
          <input type="text" id="email" {...register("email")} />
          {errors?.email && (
            <span className="error">{errors.email.message}</span>
          )}
        </div>
        <button>Enviar</button>
      </form>
    </main>
  );
}

export default App;

// Regex: las expresiones regulares son muy utiles a la hora de buscar patrones en los textos. Una utilidad
// muy importante es hacer patrones de validaciones para los inputs que usamos en nuestros formularios.

// Caracteristicas claves: los patrones suelen envolverse dentro de 2 slash // al finalizar la ultima barra
// se pueden asignar banderas (flags).

// Flags importantes:
// I: sirve para buscar patrones insensitive case.
// G: global, sirve para buscar mas de una vez el patron dentro de la cadena de texto
