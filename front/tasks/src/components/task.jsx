import { useTaskStore } from "../stores/tasks-store";

export default function Task({ id, text, completed }) {
  const { complete, delete: del } = useTaskStore();

  return (
    <li key={id}>
      <span className={`${completed && "text-green-700"}`}>{text}</span>
      {!completed && (
        <input type="checkbox" id={id} onClick={() => complete(id)} />
      )}
      <button onClick={() => del(id)}> 🗑</button>
    </li>
  );
}
