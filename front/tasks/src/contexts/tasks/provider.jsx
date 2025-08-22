import { useEffect } from "react";
import { useArray } from "../../hooks/use-array";
import TaskContext from "./context";
import { isNullOrEmpty } from "../../utils/string-validation";
import { v4 as uuidv4 } from "uuid";

export default function TaskProvider({ children }) {
  const { array: tasks, addItem, deleteOrUpdateItem, set } = useArray([]);

  useEffect(() => {
    const initial = JSON.parse(localStorage.getItem("tasks"));
    initial && set(initial);
  }, []);

  useEffect(() => {
    if (tasks.length > 0) localStorage.setItem("tasks", JSON.stringify(tasks));
  }, [tasks]);

  const addTask = (text) => {
    return new Promise((resolve, reject) => {
      if (isNullOrEmpty(text)) return reject("Invalid task");

      const taskFound = tasks.find(
        (t) => t.text == text.trim() && t.completed == false
      );
      if (taskFound) return reject("task already added or not completed");

      const task = {
        id: uuidv4(),
        text,
        completed: false,
      };
      addItem(task);
      resolve("Task added!");
    });
  };

  const completeTask = (id) => {
    const taskFound = tasks.find((t) => t.id == id);
    taskFound.completed = true;

    deleteOrUpdateItem("id", id, taskFound);
  };

  const deleteTask = (id) => {
    deleteOrUpdateItem("id", id);
  };

  return (
    <TaskContext.Provider value={{ tasks, completeTask, addTask, deleteTask }}>
      {children}
    </TaskContext.Provider>
  );
}
