import { useState } from 'react';
import { NotesService } from '../../../../services/Notes.service';
import styles from './CreateNoteModal.module.css';

const CreateNoteModal = ({
  setNotes,
  userId,
  isOpen,
  toggle,
}: ModalTypeCreate) => {
  const [note, setNote] = useState('');

  const createNote = async () => {
    if (note.length == 0) {
      alert('Void note..');
      return;
    }
    const response = await NotesService.createNewNote({
      note: note,
      userId: userId,
    });
    if (response != '') {
      alert('Your note was created!');
      setNotes(prev => [{ id: response, note: note }, ...prev]);
      toggle();
    } else {
      alert("Your note wasn't created..");
    }
  };

  return (
    <>
      {isOpen && (
        <div className={styles.modalOverlay} onClick={toggle}>
          <div className={styles.modalBox} onClick={e => e.stopPropagation()}>
            <h1 className={styles.headernote}>Write your note</h1>
            <div className={styles.line}></div>
            <textarea
              className={styles.customTextArea}
              content={note}
              onChange={e => setNote(e.target.value)}
            ></textarea>
            <div className={styles.centerbtn}>
              <button className={styles.btn} onClick={createNote}>
                Save new note
              </button>
            </div>
          </div>
        </div>
      )}
    </>
  );
};

export default CreateNoteModal;
