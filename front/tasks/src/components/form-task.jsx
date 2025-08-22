import { useEffect } from "react";
import { useTasks } from "../contexts/tasks/use-tasks";
import TaskList from "./task-list";

export default function FormTask() {
  const { addTask } = useTasks();

  const handleSubmit = (e) => {
    e.preventDefault();
    const form = e.target;
    const data = new FormData(form);
    const text = data.get("task");
    addTask(text)
      .then((msg) => {
        console.log(msg);
        form.reset();
      })
      .catch((err) => console.error(err));
  };

  return (
    <>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="task">Tarea:</label>
          <input type="text" id="task" name="task" />
        </div>
        <button>Agregar</button>
      </form>
      <TaskList title="Tareas" />
      <TaskList title="Tareas completadas:" completed />
    </>
  );
}
