import React from 'react';
import { View, Text, TouchableOpacity } from 'react-native';
import { styles } from './styles';

// Define os tipos de ações que a barra pode executar
export type MarkdownAction = 'bold' | 'italic' | 'h1' | 'h2' | 'h3' | 'list';

type Props = {
  onAction: (action: MarkdownAction) => void;
};

const ToolbarButton = ({ title, onPress }: { title: string; onPress: () => void }) => (
  <TouchableOpacity style={styles.button} onPress={onPress}>
    <Text style={styles.buttonText}>{title}</Text>
  </TouchableOpacity>
);

export default function MarkdownToolbar({ onAction }: Props) {
  return (
    <View style={styles.container}>
      <ToolbarButton title="Negrito" onPress={() => onAction('bold')} />
      <ToolbarButton title="Itálico" onPress={() => onAction('italic')} />
      <ToolbarButton title="H1" onPress={() => onAction('h1')} />
      <ToolbarButton title="H2" onPress={() => onAction('h2')} />
      <ToolbarButton title="H3" onPress={() => onAction('h3')} />
      <ToolbarButton title="Lista" onPress={() => onAction('list')} />
    </View>
  );
}