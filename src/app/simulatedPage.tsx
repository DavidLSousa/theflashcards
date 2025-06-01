import React, { useState } from 'react';
import { View, Text, Button, StatusBar, StyleSheet } from 'react-native';
import { RouteProp, useRoute } from '@react-navigation/native';
import { Card as CardModel } from '@/src/models/Card';
import { LinearGradient } from 'expo-linear-gradient';
import { colors } from '../constants/colors';
import { styles } from './styles';

type RouteParams = {
  cards: CardModel[]
};

export default function SimulateScreen() {
  const route = useRoute<RouteProp<{ params: RouteParams }, 'params'>>();
  const { cards } = route.params;

  const [index, setIndex] = useState(0);
  const currentCard = cards[index];

  const handleNext = () => {
    if (index < cards.length - 1) {
      setIndex(index + 1);
    } else {
      alert('Fim do simulado');
    }
  };

  return (
    <LinearGradient
      colors={[colors.blueLazuli, colors.blueMedium]}
      style={styles.container}
    >
      <StatusBar barStyle="light-content" backgroundColor={colors.blueLazuli} />

      <View style={stylesLocal.cardContainer}>
        <Text style={stylesLocal.question}>{currentCard.quest}</Text>
        <Text style={stylesLocal.answer}>{currentCard.resp}</Text>

        <Button title="Não responder" onPress={handleNext} />
      </View>

    </LinearGradient>
  );
};

const stylesLocal = StyleSheet.create({
  cardContainer: {
    backgroundColor: '#fff',
    borderRadius: 12,
    padding: 20,
    marginHorizontal: 20,
    marginVertical: 40,
    elevation: 4, // sombra no Android
    shadowColor: '#000', // sombra no iOS
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.2,
    shadowRadius: 4,
  },
  question: {
    fontSize: 18,
    fontWeight: 'bold',
    color: '#333',
    marginBottom: 12,
    alignSelf: 'center',
  },
  answer: {
    fontSize: 16,
    color: '#666',
    marginBottom: 20,
    alignSelf: 'center',
  },
});

