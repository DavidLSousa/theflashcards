import { View, Text, TextInput, Modal, StyleSheet } from "react-native";
import { useState } from "react";

import Button from "../button";
import { styles } from "./styles";
import { useCard } from "@/src/hooks/useCard";

type Props = {
  id: string;
}

export default function Index({ id }: Props) {

  const card = useCard((state) => state.cards).find((card) => card.id === id)!;
  const toggleAnswer = useCard((state) => state.toggleAnswer);

  const { editCard, removeCard } = useCard();

  const [modalVisible, setModalVisible] = useState(false);
  const [quest, setQuest] = useState(card.quest);
  const [resp, setResp] = useState(card.resp);
  const [category, setCategory] = useState(card.category);

  function handleSave() {
    editCard({
      id: card.id,
      quest,
      resp,
      category,
    });
    setModalVisible(false);
  }

  function handleDelete() {
    removeCard(card.id);
    setModalVisible(false);
  }

  return (
    <View style={styles.container}>
      <Text style={styles.category}>{card.category}</Text>
      <Text style={styles.quest}>{card.quest}</Text>

      {card.isAnswerVisible && (
        <Text style={styles.resp}>{card.resp}</Text>
      )}

      <Button
        title={card.isAnswerVisible ? "Ocultar Resposta" : "Ver Resposta"}
        onPress={() => toggleAnswer(card.id)}
      />

      <Button title="Editar" onPress={() => setModalVisible(true)} />

      <Modal
        visible={modalVisible}
        animationType="slide"
        transparent={true}
        onRequestClose={() => setModalVisible(false)}
      >
        <View style={styleModal.overlay}>
          <View style={styleModal.modalContainer}>
            <Text>Categoria:</Text>
            <TextInput
              value={category}
              onChangeText={setCategory}
              style={styleModal.input}
            />

            <Text>Questão:</Text>
            <TextInput
              value={quest}
              onChangeText={setQuest}
              multiline
              style={styleModal.textarea}
            />

            <Text>Resposta:</Text>
            <TextInput
              value={resp}
              onChangeText={setResp}
              multiline
              style={styleModal.textarea}
            />

            <View style={styleModal.buttonRow}>
              <Button title="Salvar" onPress={handleSave} />
              <Button title="Deletar" onPress={handleDelete} />
              <Button title="Cancelar" onPress={() => setModalVisible(false)} />
            </View>
          </View>
        </View>
      </Modal>
    </View>
  );
}

const styleModal = StyleSheet.create({
  overlay: {
    flex: 1,
    backgroundColor: 'rgba(0,0,0,0.5)',
    justifyContent: 'center',
    padding: 20,
  },
  modalContainer: {
    backgroundColor: 'white',
    borderRadius: 8,
    padding: 20,
  },
  input: {
    borderWidth: 1,
    borderColor: '#ccc',
    borderRadius: 4,
    marginBottom: 10,
    padding: 8,
  },
  textarea: {
    borderWidth: 1,
    borderColor: '#ccc',
    borderRadius: 4,
    marginBottom: 10,
    padding: 8,
    height: 60,
    textAlignVertical: 'top',
  },
  buttonRow: {
    flexDirection: 'row',
    justifyContent: 'space-between',
  },
});
