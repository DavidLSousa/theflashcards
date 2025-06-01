import React, { useState } from 'react';
import { View, Text, StatusBar, StyleSheet, ScrollView } from 'react-native';
import { RouteProp, useRoute } from '@react-navigation/native';
import { Card as CardModel } from '@/src/models/Card';
import { LinearGradient } from 'expo-linear-gradient';
import { colors } from '../constants/colors';
import { styles } from './styles';
import Button from '@/src/components/button';
import { router } from 'expo-router';

type RouteParams = {
  cards: CardModel[];
};

export default function SimulatePage() {
  const route = useRoute<RouteProp<{ params: RouteParams }, 'params'>>();
  const { cards } = route.params;

  const [index, setIndex] = useState(0);
  const [showAnswer, setShowAnswer] = useState(false);

  if (!cards || cards.length === 0) {
    return (
      <View style={[styles.container, { justifyContent: 'center', alignItems: 'center' }]}>
        <Text style={{ color: 'white', fontSize: 18 }}>Nenhum card disponível.</Text>
        <Text style={{ color: 'white', fontSize: 18 }}>Você pode criar voltando na pagina inicial e clicando em "Criar Flash Card".</Text>
      </View>
    );
  }

  const currentCard = cards[index];

  const handleNext = () => {
    if (index < cards.length - 1) {
      setIndex(index + 1);
      setShowAnswer(false);
    } else {
      alert('Fim do simulado');
      router.back();
    }
  };

  return (
    <LinearGradient
      colors={[colors.blueLazuli, colors.blueMedium]}
      style={styles.container}
    >
      <StatusBar barStyle="light-content" backgroundColor={colors.blueLazuli} />

      <ScrollView contentContainerStyle={styles.scrollContent}>
        <View style={localStyles.cardContainer}>
          <Text style={localStyles.category}>{currentCard.category}</Text>
          <Text style={localStyles.quest}>{currentCard.quest}</Text>

          {showAnswer && <Text style={localStyles.resp}>{currentCard.resp}</Text>}

          <View style={styles.form}>
            <Button
              title={showAnswer ? 'Ocultar Resposta' : 'Ver Resposta'}
              onPress={() => setShowAnswer(prev => !prev)}
            />
            <Button title="Próxima" onPress={handleNext} />
          </View>
        </View>
      </ScrollView>
    </LinearGradient>
  );
}

const localStyles = StyleSheet.create({
  cardContainer: {
    backgroundColor: colors.whiteIce,
    borderRadius: 12,
    padding: 20,
    elevation: 8,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.2,
    shadowRadius: 4,
  },
  category: {
    color: colors.blueLazuli,
    marginBottom: 10,
    fontWeight: 'bold',
    fontSize: 14,
  },
  quest: {
    fontSize: 24,
    marginVertical: 10,
    color: colors.blueDark,
    textAlign: 'center',
  },
  resp: {
    fontSize: 20,
    marginVertical: 10,
    color: colors.blueDark,
    textAlign: 'center',
  },
});
