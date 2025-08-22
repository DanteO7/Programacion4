import { useContext } from "react";
import TaskContext from "./context";

export const useTasks = () => {
  const { tasks, completeTask, addTask, deleteTask } = useContext(TaskContext);

  return { tasks, completeTask, addTask, deleteTask };
};
