import { useTasks } from "../contexts/tasks/use-tasks";

export default function Task({ id, text, completed }) {
  const { deleteTask, completeTask } = useTasks();

  return (
    <li key={id}>
      <span className={`${completed && "text-green-700"}`}>{text}</span>
      {!completed && (
        <input type="checkbox" id={id} onClick={() => completeTask(id)} />
      )}
      <button onClick={() => deleteTask(id)}> 🗑</button>
    </li>
  );
}
