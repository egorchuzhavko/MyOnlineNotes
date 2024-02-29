import NoteItem from './content-noteItem/NoteItem';
import styles from './MainpageContent.module.css';

interface props {
  listNotes: INotesState[];
  setCurrentNote: React.Dispatch<React.SetStateAction<INotesState>>;
  toggle: () => void;
}

const MainpageContent = ({ listNotes, setCurrentNote, toggle }: props) => {
  return (
    <div className={styles.container}>
      {listNotes.length > 0 ? (
        listNotes.map(note => (
          <NoteItem
            key={note.id}
            noteItem={note}
            setCurrentNote={setCurrentNote}
            toggle={toggle}
          />
        ))
      ) : (
        <h2 style={{ color: 'white', marginTop: '3em' }}>
          You don't have any notes
        </h2>
      )}
    </div>
  );
};

export default MainpageContent;
