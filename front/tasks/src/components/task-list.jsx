import { useTasks } from "../contexts/tasks/use-tasks";
import Task from "./task";

export default function TaskList({ title, completed = false }) {
  const { tasks } = useTasks();
  return (
    <section className="border border-black p-2">
      <h3>{title}</h3>
      <ul>
        {tasks
          ?.filter((t) => t.completed == completed)
          .map((t) => (
            <Task key={t.id} {...t} />
          ))}
      </ul>
    </section>
  );
}
