import { View, Text } from "react-native";

import Button from "../button";
import { styles } from "./styles";

type Props = {
  showAnswer: boolean;
  setShowAnswer: (showAnswer: boolean) => void;
}

export default function Card({showAnswer, setShowAnswer}: Props) {
  return (
    <View style={styles.container}>

      <Text style={styles.category}>Categoria do Card 1</Text>

      <Text style={styles.quest}>Pergunta do Card 1</Text>

      {showAnswer && (
        <Text style={styles.resp}>Resposta do Card 1</Text>
      )}

      <Button
        title={showAnswer ? "Ocultar Resposta" : "Ver Resposta"}
        onPress={() => setShowAnswer(!showAnswer)}
      />
    </View>
  );
}