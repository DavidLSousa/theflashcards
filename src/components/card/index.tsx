import { View, Text } from "react-native";

import Button from "../button";
import { styles } from "./styles";
import { useCard } from "@/src/hooks/useCard";

type Props = {
  id: string;
}

export default function Index({id}: Props) {
  
  const card = useCard(
    (state) => state.cards)
    .find((card) => card.id === id)!;
  const toggleAnswer = useCard((state) => state.toggleAnswer); 

  return (
    <View style={styles.container}>

      <Text style={styles.category}>
        {card.category}
      </Text>

      <Text style={styles.quest}>
        {card.quest}
      </Text>

      {card.isAnswerVisible && (
        <Text style={styles.resp}>
          {card.resp}
        </Text>
      )}

      <Button
        title={card.isAnswerVisible ? "Ocultar Resposta" : "Ver Resposta"}
        onPress={() => toggleAnswer(card.id)}
      />
    </View>
  );
}