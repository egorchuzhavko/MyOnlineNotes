import styles from './NoteItem.module.css';

interface props {
  noteItem: INotesState;
  setCurrentNote: React.Dispatch<React.SetStateAction<INotesState>>;
  toggle: () => void;
}

const NoteItem = ({ noteItem, setCurrentNote, toggle }: props) => {
  const callModal = () => {
    setCurrentNote(noteItem);
    toggle();
  };
  return (
    <button className={styles.container} onClick={callModal}>
      <p className={styles.btntext}>
        {noteItem.note.length > 200
          ? noteItem.note.slice(0, 200) + '...'
          : noteItem.note}
      </p>
    </button>
  );
};

export default NoteItem;
