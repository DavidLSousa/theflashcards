import React from 'react';
import { StyleSheet, StyleProp, TextStyle } from 'react-native';
import Markdown from 'react-native-markdown-display';

type Props = {
  content: string;
  style?: StyleProp<TextStyle>;
};

export default function MarkdownRenderer({ content, style }: Props) {
  const flattenedStyle = StyleSheet.flatten(style);

  // Em seguida, mesclamos os estilos base com os estilos achatados em um novo objeto.
  const mergedStyles = {
    ...markdownStyles,
    body: {
      ...markdownStyles.body, // Estilos base definidos abaixo
      ...flattenedStyle,      // Estilos customizados (sobrescrevem os base, se houver conflito)
    },
  };

  return (
    <Markdown style={mergedStyles}>
      {content}
    </Markdown>
  );
}

const markdownStyles = StyleSheet.create({
  body: {},
  heading1: {
    fontSize: 32,
    fontWeight: 'bold',
    marginBottom: 10,
  },
  heading2: {
    fontSize: 28,
    fontWeight: 'bold',
    marginBottom: 8,
  },
  strong: {
    fontWeight: 'bold',
  },
  em: {
    fontStyle: 'italic',
  },
  bullet_list_icon: {
    fontSize: 16,
    marginRight: 8,
  },
  ordered_list_icon: {
    fontSize: 16,
    marginRight: 8,
  }
});