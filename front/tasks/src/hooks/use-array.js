import { useState } from "react";
import { isNullOrEmpty } from "../utils/string-validation";

export const useArray = (arr = []) => {
  const [array, setArray] = useState(arr);

  const addItem = (item) => setArray([...array, item]);

  const deleteOrUpdateItem = (key = "", value, newItem = null) => {
    let updatedArr;
    if (isNullOrEmpty(key)) {
      updatedArr = array.filter((i) => i != value);
    } else {
      updatedArr = array.filter((i) => i[key] != value);
    }
    if (newItem == null) {
      setArray(updatedArr);
    } else {
      setArray([...updatedArr, newItem]);
    }
  };

  return { array, addItem, deleteOrUpdateItem, set: setArray };
};
