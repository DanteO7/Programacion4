import { useTasks } from "../contexts/tasks/use-tasks";
import TaskList from "./task-list";
import { useTaskStore } from "../stores/tasks-store";

export default function FormTask() {
  const { add } = useTaskStore((state) => state);

  const handleSubmit = (e) => {
    e.preventDefault();
    const form = e.target;
    const data = new FormData(form);
    const text = data.get("task");

    add(text);
    form.reset();
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
