import * as React from 'react';
import ReactDOM from 'react-dom';
import { ProgressIndicator } from '@fluentui/react/lib/ProgressIndicator';

export function renderProgressBar(count) {
    const Progress = () => React.createElement(
        ProgressIndicator,
        {
            'label': 'Summarising...',
            'description': ''
        },
        null
    );

    ReactDOM.render(Progress(), document.getElementById('progressBar'));
}
